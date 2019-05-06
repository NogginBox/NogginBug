/*
 * A bit like jQuery. Makes working with the DOM easier
 * I wrote this for places.nogginbox.co.uk a personal project I'm experimenting with vanilla JS on
 */
var _dom = function (d) {
    var html = function (el) {
        var _el = el;

        // Todo: rethrink mechanism of operating on single of array of els
        var eachFunc = function (func) {
            if (_el.length !== undefined) {
                for (var i = 0; i < _el.length; i++) {
                    func(html(_el[i]));
                }
            }
            else {
                func(html(_el));
            }
        };

        var eachProp = function (propName, value) {
            for (var i = 0; i < _el.length; i++) {
                _el[i][propName] = value;
            }
        };

        var checked = function (boolV) {
            if (boolV === undefined) {
                return _el.checked;
            }
            _el.checked = !!boolV;
            return this;
        };

        // IE10+ (Todo: Shim)
        var classAdd = function (cName) {
            if (_el.classList) {
                _el.classList.add(cName);
            }
            else {
                eachFunc(function (el) { el.classAdd(cName); });
            }
            return this;
        };

        // IE10+ (Todo: Shim)
        var classRemove = function (cName) {
            if (_el.classList) {
                _el.classList.remove(cName);
            }
            else {
                eachFunc(function (el) { el.classRemove(cName); });
            }
            return this;
        };

        var classToggle = function (cName) {
            if (_el.classList) {
                if (_el.classList.contains(cName)) {
                    classRemove(cName);
                }
                else {
                    classAdd(cName);
                }
            }
            else {
                eachFunc(function (el) { el.classToggle(cName); });
            }
            return this;
        };

        var data = function (key, val) {
            return prop("data-" + key, val);
        };

        var dataObject = function (key) {
            dKey = ("data-" + key + "-").replace("--", "-");
            var dPattern = new RegExp(dKey, "i");
            var d = {};

            [].forEach.call(_el.attributes, function (at) {
                if (dPattern.test(at.name)) {
                    var val = at.value
                    try {
                        val = JSON.parse(val);
                    }
                    catch (e) {
                        // Ignore, use unparsed value
                    }
                    d[at.name.substr(dKey.length)] = val;
                }
            });
            return d;
        };

        var on = function (action, func, eventClosure) {
            if (!_el) return;

            var createHtmlFunc = function (c) {
                var closure = c;
                return function (ev) {
                    var handled = func(html(ev.currentTarget), closure, ev);

                    // Handled events will stop further propogation.
                    if (handled === true) ev.stopPropagation();
                };
            };
                
            eachFunc(function (el) {
                el.element.addEventListener(action, createHtmlFunc(eventClosure));
            });
            return this;
        }

        var onchange = function (func, eventClosure) { return on("change", func, eventClosure); };
        var onclick = function (func, eventClosure) { return on("click", func, eventClosure); };
        var onmouseleave = function (func, eventClosure) { return on("mouseleave", func, eventClosure); };
        var onmouseover = function (func, eventClosure) { return on("mouseover", func, eventClosure) };

        var prop = function (key, val) {
            if (val === undefined) {
                return _el.getAttribute(key);
            }
            _el.setAttribute(key, val);
            return this;
        };

        /**
         * Creates a list of values by evaluating the function on all elements in the collection
         * Null or undefined values are ignored
         * @param {function} valFunc
         */
        var select = function (valFunc) {
            var list = [];
            for (var i = 0; i < _el.length; i++) {
                var v = valFunc(html(_el[i]));
                if (v !== null && v !== undefined) list.push(v);
            }
            return list;
        };

        /*var trigger = function (name) {
            var event = new CustomEvent(name);
            eachFunc(function () { dispatchEvent(event); });
        };*/

        /**
         * Returns a new _dom collection with elements that return true for the boolFunc
         * @param {function} boolFunc
         */
        var where = function (boolFunc) {
            var list = [];
            for (var i = 0; i < _el.length; i++) {
                if (boolFunc(html(_el[i]))) {
                    list.push(_el[i]);
                }
            }
            return html(list);
        };

        var val = function (v) {
            if (!v) {
                return _el.value;
            }
            _el.value = v;
            return this;
        };

        // todo: tailor function to if object is single or collection of HTML nodes
        return {
            checked: checked,
            classAdd: classAdd,
            classRemove: classRemove,
            classToggle: classToggle,
            data: data,
            dataObject: dataObject,
            eachFunc: eachFunc,
            eachProp: eachProp,
            element: _el,
            onchange: onchange,
            onclick: onclick,
            onmouseleave: onmouseleave,
            onmouseover: onmouseover,
            prop: prop,
            select: select,
            //trigger: trigger,
            where: where,
            whereHasClass: whereHasClassFuncFactory(el),
            whereCssSelector: whereSelectorFuncFactory(el),
            val: val
        };
    };

    var createA = function (innerHtml, onClick) {
        var a = document.createElement("a");
        a.innerHTML = innerHtml;
        a.onclick = onClick;
        return html(a);
    };

    var createP = function (innerHtml) {
        var p = document.createElement("p");
        p.innerHTML = innerHtml;
        return html(p);
    };

    var createDiv = function (innerHtml, cssClass) {
        var p = document.createElement("div");
        p.className = cssClass;
        p.innerHTML = innerHtml;
        return html(p);
    };

    var findId = function (id) {
        return html(document.getElementById(id));
    };

    var whereHasClassFuncFactory = function (el) {
        return function (cName) {
            return html(el.getElementsByClassName(cName));
        };
    };

    var whereHasNameFuncFactory = function (el) {
        return function (name) {
            return html(el.querySelectorAll("[name=" + name + "]"));
        };
    };

    var whereSelectorFuncFactory = function (el) {
        return function (selector) {
            return html(el.querySelectorAll(selector));
        };
    };

    

    return {
        create: {
            a: createA,
            div: createDiv,
            p: createP
        },
        findId: findId,
        whereCssSelector: whereSelectorFuncFactory(d),
        whereHasClass: whereHasClassFuncFactory(d),
        whereHasName: whereHasNameFuncFactory(d)
    }
}(document);