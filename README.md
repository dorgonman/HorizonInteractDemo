[Marketplace](https://www.unrealengine.com/marketplace/en-US/product/horizon-interact-plugin) 

[![Build Status](https://dev.azure.com/hsgame/UE4HorizonPlugin/_apis/build/status/HorizonInteract/HorizonInteractDemo-Shipping-CI?repoName=HorizonInteractDemo&branchName=main)](https://dev.azure.com/hsgame/UE4HorizonPlugin/_build/latest?definitionId=51&repoName=HorizonInteractDemo&branchName=main)

public feed: nuget.org  

[![nuget.org package in feed in ](https://img.shields.io/nuget/v/HorizonInteractDemo.svg)](https://www.nuget.org/packages/HorizonInteractDemo/)
  

Note: 

main branch may be unstable since it is in development, please switch to tags, for example: editor/4.26.0.1

How to Run Demo Project before purchase:(Only for Win64 editor build, no source code)
1. Double click install_game_package_from_nuget_org.cmd, and check if UE4Editor-*.dll are installed to Binaries\Win64 and Plugins\HorizonInteractDemo\Binaries\Win64\
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
User Guide: Quick Start
-----------------------

1. Create Blueprint class that inherited from HorizonInteractObject_SphereTrigger and setup HintWidgetComponent.

  ![Create Interact Object](./ScreenShot/HorizonInteract_ScreenShot_CreateObject.png)  

2. Add HorizonInteractorComponent into Default Pawn Classe.  

![Add HorizonInteractorComponent](./ScreenShot/HorizonInteract_ScreenShot_AddInteractorIntoPawn.png)  

3. Setup Collision and Collision Profile for Interactor and InteractObject.

![CollisionProfile Interactor](./ScreenShot/HorizonInteract_ScreenShot_CollisionProfile_Overview.png)

Interactor             |  InteractObject
:-------------------------:|:-------------------------:
![CollisionProfile Interactor](./ScreenShot/HorizonInteract_ScreenShot_CollisionProfile_Interactor.png) |  ![CollisionProfile InteractObject](./ScreenShot/HorizonInteract_ScreenShot_CollisionProfile_InteractObject.png)
![CollisionProfile Interactor](./ScreenShot/HorizonInteract_ScreenShot_Collision_Interactor.png) |   ![CollisionProfile InteractObject](./ScreenShot/HorizonInteract_ScreenShot_Collision_InteractObject.png)


4. InputAction Setup: Project Setting

Open Project Setting and Add InputAction Interact

![InputAction](./ScreenShot/HorizonInteract_ScreenShot_InputAction_Interactor1.png)


5. InputAction Setup: Call Input Action in Controller Pawn.

![InputAction](./ScreenShot/HorizonInteract_ScreenShot_InputAction_Interactor2.png)


6. InteractObject: Override OnInteractStarted

![OnInteractStarted](./ScreenShot/HorizonInteract_ScreenShot_InputAction_InteractObject1.png)

You should call FinishInteract when your interaction finished:

![OnInteractFinished](./ScreenShot/HorizonInteract_ScreenShot_InputAction_InteractObject2.png)

  
-----------------------
Technical Details
-----------------------

Features:

1. AHorizonInteractCharacter and AHorizonInteractObject support SphereTrigger, BoxTrigger and CapsuleTrigger for interaction.
  
2. Flexible callbacks for customization: OnInteractStarted, OnInteractTickStarted, OnInteractTick, OnInteractFinished, OnInteractAborted and OnInteractHintWidgetVisibility.

3. UHorizonInteractorComponent support InteractPressed and InteractReleased Server RPC with network prediction.

4. InteractObject support InteractStartDelay, ex: hold down the button for 2 seconds to open the door.

5. Use UHorizonInteractObjectSelector to select which InteractObject that Interactor want to interact, current selector implemented in plugin: PreferNearest, PreferNearestWithSameDirection, PreferNearestOnlySameDirection and UnderCursor.

Code Modules:

 HorizonInteract (Runtime)


Network Replicated: False  

Supported Development Platforms: Win64, Mac, Linux  

Supported Target Build Platforms: All Platforms  

Tested Platform: Win64  

Documentation: https://github.com/dorgonman/HorizonInteractDemo  

Example Project: https://github.com/dorgonman/HorizonInteractDemo  

The goal of this plugin is to provide a general Interact System that can be custotmized for different gameplay. You to interact with character or object using different  method, for example, limit the player can only interact with the object that player face or under the mouse cursor.


[DemoVideo](https://youtu.be/wdclGx1IIwQ)  
[TutorialVideo](https://www.youtube.com/watch?v=l-WCsGpg_fo&feature=youtu.be)

-----------------------
What does your plugin do/What is the intent of your plugin
-----------------------  

The goal of this plugin is to provide a general Interact System that can be custotmized for different gameplay.

-----------------------
Contact and Support
-----------------------

email: dorgonman@hotmail.com  

-----------------------
 Version History
-----------------------

*4.26.0  

        NEW: First Version including core features.  