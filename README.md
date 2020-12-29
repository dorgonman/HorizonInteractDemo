[Marketplace](https://www.unrealengine.com/marketplace/en-US/horizon-ui-plugin) 

public feed: nuget.org  

[![nuget.org package in feed in ](https://img.shields.io/nuget/v/HorizonUIPluginDemo.svg)](https://www.nuget.org/packages/HorizonUIPluginDemo/)
  
[Automation Test Result](http://horizon-studio.net/ue4/HorizonUIPluginDemo_TestReport/)


Note: 

master branch may be unstable since it is in development, please switch to tags, for example: editor/hsgame/4.25.0.290

How to Run Demo Project before purchase:(Only for Win64 editor build, no source code)
1. Double click install_game_package_from_nuget_org.cmd, and check if UE4Editor-*.dll are installed to Binaries\Win64 and Plugins\HorizonUIPlugin\Binaries\Win64\
2. Double click HorizonInteractDemo.uproject  

  
----------------------------------------------
              HorizonInteract
                 4.26.0
         http://dorgon.horizon-studio.net
          	dorgonman@hotmail.com
----------------------------------------------
   
-----------------------
System Requirements
-----------------------

Supported UnrealEngine version: 4.26
 

-----------------------
Installation Guide
-----------------------

If you want to use plugins in C++, you should add associated module to your project's 
YOUR_PROJECT.Build.cs:
PublicDependencyModuleNames.AddRange(new string[] { "HorizonInteract"});

-----------------------
User Guide: 
-----------------------


-----------------------
Technical Details
-----------------------

List of Modules:
HorizonUI (Runtime)
Intended Platform: All Platforms
Platforms Tested: Win64

Demo Project: https://github.com/dorgonman/HorizonInteractDemo  
DemoVideo: 

-----------------------
What does your plugin do/What is the intent of your plugin
-----------------------  

	
-----------------------
Contact and Support
-----------------------

email: dorgonman@hotmail.com  

-----------------------
 Version History
-----------------------

*4.26.0
