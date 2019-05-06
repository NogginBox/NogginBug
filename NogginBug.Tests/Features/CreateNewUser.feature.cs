We could not find a data exchange file at the path System.Configuration.ConfigurationErrorsException: SpecFlow configuration error ---> System.Xml.XmlException: Data at the root level is invalid. Line 1, position 1.

Please open an issue at https://github.com/techtalk/SpecFlow/issues/
Complete output: 
System.Configuration.ConfigurationErrorsException: SpecFlow configuration error ---> System.Xml.XmlException: Data at the root level is invalid. Line 1, position 1.
   at System.Xml.XmlTextReaderImpl.Throw(Exception e)
   at System.Xml.XmlTextReaderImpl.ParseRootLevelWhitespace()
   at System.Xml.XmlTextReaderImpl.ParseDocumentContent()
   at System.Configuration.ConfigurationSection.DeserializeSection(XmlReader reader)
   at TechTalk.SpecFlow.Configuration.ConfigurationSectionHandler.CreateFromXml(String xmlContent)
   at TechTalk.SpecFlow.Generator.Configuration.GeneratorConfigurationProvider.GetPlugins(SpecFlowConfigurationHolder configurationHolder)
   --- End of inner exception stack trace ---
   at TechTalk.SpecFlow.Generator.Configuration.GeneratorConfigurationProvider.GetPlugins(SpecFlowConfigurationHolder configurationHolder)
   at TechTalk.SpecFlow.Generator.GeneratorContainerBuilder.LoadPlugins(ObjectContainer container, IGeneratorConfigurationProvider configurationProvider, SpecFlowConfigurationHolder configurationHolder)
   at TechTalk.SpecFlow.Generator.GeneratorContainerBuilder.CreateContainer(SpecFlowConfigurationHolder configurationHolder, ProjectSettings projectSettings)
   at TechTalk.SpecFlow.Generator.TestGeneratorFactory.CreateGenerator(ProjectSettings projectSettings)
   at TechTalk.SpecFlow.VisualStudio.CodeBehindGenerator.Actions.GenerateTestFileAction.GenerateTestFile(GenerateTestFileParameters opts)



Command: C:\USERS\RICHARD\APPDATA\LOCAL\MICROSOFT\VISUALSTUDIO\16.0_5C5FC482\EXTENSIONS\BERSOAIN.01B\TechTalk.SpecFlow.VisualStudio.CodeBehindGenerator.exe
Parameters: GenerateTestFile --featurefile C:\Users\Richard\AppData\Local\Temp\tmpF26A.tmp --outputdirectory C:\Users\Richard\AppData\Local\Temp --projectsettingsfile C:\Users\Richard\AppData\Local\Temp\tmpF269.tmp
Working Directory: 
