# AGENTS.md - HorizonInteractDemo Development Guide

## Project Overview
HorizonInteractDemo is an Unreal Engine plugin (v4.26-5.7) providing a flexible interaction system for game development. The project includes both the plugin source code and a demo project.

**Key Paths:**
- Plugin Source: `Plugins/HorizonInteract/Source/HorizonInteract/`
- Demo Project: `Source/HorizonInteractDemo/`
- Build Scripts: `Build/Script/HorizonInteractDemo.Automation/`

## Build & Development Commands

### Project Setup
```bash
# Generate Visual Studio project files
./git_checkout_main.sh          # Checkout main branch with submodules
./git_submodule_update.sh       # Update submodules
```

### Building
```bash
# Build the project (requires Unreal Engine installed)
# Use Unreal Automation Tool or Visual Studio

# For Win64 Editor build
Engine/Build/BatchFiles/Build.bat HorizonInteractDemoEditor Win64 Development

# For Shipping build
Engine/Build/BatchFiles/Build.bat HorizonInteractDemo Win64 Shipping
```

### Running Tests
```bash
# Run automation tests in editor
# Tests are located in: Plugins/HorizonInteract/Source/HorizonInteract/Private/Test/HorizonInteract.spec.cpp

# Via Unreal Editor:
# 1. Open project in editor
# 2. Window > Developer Tools > Automation
# 3. Search for "Plugin.HorizonInteract" tests
# 4. Click "Start Tests"

# Via command line:
Engine/Build/BatchFiles/RunUAT.bat BuildPlugin -Plugin="Plugins/HorizonInteract/HorizonInteract.uplugin" -CreateSubFolder -TargetPlatforms=Win64
```

### Running Single Test
```bash
# Run specific automation test via command line
Engine/Build/BatchFiles/RunUAT.bat BuildCook -Project=HorizonInteractDemo.uproject -TargetPlatforms=Win64 -Automation
```

## Code Style Guidelines

### C++ Naming Conventions
- **Classes**: PascalCase with prefix (A for Actors, U for Components/Objects)
  - `AHorizonInteractObject`, `UHorizonInteractorComponent`
- **Functions**: PascalCase
  - `BeginPlay()`, `OnInteractStarted()`
- **Variables**: PascalCase with prefix
  - `bCanEverTick` (bool prefix 'b')
  - `InInteractorController` (parameter prefix 'In')
  - `pWidgetComponent` (pointer prefix 'p')
- **Constants**: PascalCase with prefix
  - `TEXT("SomeName")` for string literals
- **Enums**: PascalCase with E prefix
  - `EHorizonInteractObjectAbortReason`

### File Organization
- **Headers**: `Public/` directory with `.h` extension
- **Implementation**: `Private/` directory with `.cpp` extension
- **Modules**: Organized by feature (Component/, Selector/, etc.)
- **Generated Code**: Include via `#include UE_INLINE_GENERATED_CPP_BY_NAME(ClassName)`

### Formatting & Indentation
- **Indent**: 4 spaces (configured in `.editorconfig`)
- **Line Length**: Max 120 characters
- **Braces**: Allman style (opening brace on new line)
- **Charset**: UTF-8

### Includes & Dependencies
- **Order**: Generated includes last
  - `#include "CoreMinimal.h"`
  - `#include "GameFramework/Actor.h"`
  - `#include "ClassName.generated.h"`
- **Forward Declarations**: Use in headers to reduce dependencies
  - `class UHorizonInteractObjectComponent;`
- **Module Dependencies**: Defined in `.Build.cs` files
  - Public: Core, Engine
  - Private: CoreUObject, Slate, SlateCore, UMG

### Types & Declarations
- **UCLASS()**: For Unreal classes with reflection
- **UPROPERTY()**: For exposed properties with specifiers
  - `VisibleAnywhere`, `BlueprintReadOnly`, `Category`
- **UFUNCTION()**: For exposed functions
  - `BlueprintNativeEvent`, `Category`
- **TObjectPtr<>**: Smart pointer for UObject references
- **Null Checks**: Always check before dereferencing

### Error Handling
- **Assertions**: Use `check()` for critical errors
- **Validation**: Use `if (Pointer)` before access
- **Logging**: Use `UE_LOG()` with appropriate verbosity
- **Return Values**: Use bool or void with side effects

### Comments & Documentation
- **File Header**: Include copyright, date, author, email
  ```cpp
  // Created by dorgon, All Rights Reserved.
  // Date of intended publication: 2021/01/09
  // email: dorgonman@hotmail.com
  ```
- **Function Comments**: Describe purpose and parameters
- **Inline Comments**: Explain non-obvious logic
- **Category Tags**: Use `Category = "HorizonPlugin|Interact"` in UFUNCTION/UPROPERTY

### Lambda & Callbacks
- **Weak Lambdas**: Use `AddWeakLambda()` to avoid circular references
  ```cpp
  InteractObjectComponent->OnInteractStartedEventNative.AddWeakLambda(this, 
    [this](AController* InInteractorController) { OnInteractStarted(InInteractorController); });
  ```
- **Delegate Binding**: Prefer weak bindings for actor callbacks

### Performance Considerations
- **Tick**: Disable `PrimaryActorTick.bCanEverTick` if not needed
- **Scope Counters**: Use `DECLARE_HORIZONINTERACT_QUICK_SCOPE_CYCLE_COUNTER` for profiling
- **Network**: Use `bUseNetworkLocalPrediction` for client-side prediction

## Module Structure

### HorizonInteract Plugin Module
- **Type**: Runtime
- **Location**: `Plugins/HorizonInteract/Source/HorizonInteract/`
- **Public API**: Exposed via `HORIZONINTERACT_API` macro
- **Build Definition**: `WITH_HORIZONINTERACT=1`

### Key Classes
- `AHorizonInteractObject`: Base actor for interactive objects
- `AHorizonInteractCharacter`: Base character with interaction support
- `UHorizonInteractorComponent`: Component for interacting with objects
- `UHorizonInteractObjectComponent`: Component for interactive objects
- `UHorizonInteractObjectSelector`: Base class for selection logic

## Testing
- **Framework**: Unreal Automation Tests (FAutomationTestBase)
- **Location**: `Private/Test/HorizonInteract.spec.cpp`
- **Conditional**: Wrapped in `#if WITH_DEV_AUTOMATION_TESTS`
- **Version Compatibility**: Handle UE version differences with preprocessor checks

## CI/CD Pipeline
- **Platform**: Azure Pipelines (`.azure-pipelines/azure-pipelines.yml`)
- **Triggers**: Changes to Source/, Plugins/, Content/, or .uproject
- **Targets**: Win64, Android, Mac
- **Artifact**: NuGet package published to nuget.org

## Version Management
- **Current**: 5.7.0 (version 40)
- **Supported UE**: 4.26 - 5.7
- **Versioning**: Aligned with Unreal Engine versions
- **Tags**: Use format `editor/X.Y.Z.N` for releases

## Important Notes
- Main branch may be unstable; use tagged releases for production
- Network replication not handled by plugin; implement in project
- Plugin uses Reliable RPC for network communication
- Enable replication on actors/components modified by interact callbacks
