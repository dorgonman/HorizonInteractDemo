# AGENTS.md — HorizonInteractDemo

Unreal Engine 5.7 plugin demo project. Build/test via `Build/Script/` local overrides and `Build/Base/Script/` shared scripts.

## Quick Start

From repo root (Git Bash on Windows):
```sh
./git_submodule_update.sh
./git_checkout_main.sh
```

## Build Commands

Run from Git Bash on Windows unless noted otherwise.

**Plugin (Shipping):**
```sh
./Build/Script/win64/plugin/shipping.sh
```

**Standalone (Development):**
```sh
./Build/Base/Script/win64/standalone/development.sh
```

## Test Commands

**Run full test suite:**
```sh
./Build/Script/win64/editor/test.sh
```

**Run single automation test:**
```sh
export EXTRA_PARAMETERS='-ExecCmds="Automation RunTests Plugin.HorizonInteract; Quit"'
AUTOMATION_TEST_FILTER='Plugin.HorizonInteract' ./Build/Script/win64/editor/test.sh
```

Available tests (from `Plugins/HorizonInteract/Source/HorizonInteract/Private/Test/`):
- `Plugin.HorizonInteract`

## Code Style & Conventions

### Naming (Unreal Standard)
- `U` prefix: UObject-derived classes
- `A` prefix: AActor-derived classes
- `S` prefix: Slate widgets
- `F` prefix: structs
- `E` prefix: enums
- `T` prefix: template types
- `b` prefix: bool variables (e.g., `bIsEnabled`)

### Includes & Headers
- Use `#pragma once` in all headers
- Include generated header **last**: `#include "<File>.generated.h"`
- In `.cpp`: include matching header first, then local module headers, then engine headers
- Prefer forward declarations in headers

### Types & Ownership
- Prefer Unreal types: `int32`, `uint8`, `float`, `FString`, `FName`, `FText`, `FVector2D`
- Use UE containers: `TArray`, `TMap`, `TOptional`
- For UObjects:
  - `TObjectPtr<T>` for owning UPROPERTY references (UE5)
  - `TWeakObjectPtr<T>` for weak references
  - `TSoftObjectPtr<T>` for soft asset references

### Error Handling & Logging
- Use UE assertion macros: `check`, `checkf` (fatal), `ensure`, `ensureMsgf` (non-fatal)
- Plugin logging category: `LogHorizonInteract`
- Convenience macros in `HorizonInteractPrivate.h`:
  - `UE_HORIZONINTERACT_FATAL/ERROR/WARNING/DISPLAY/LOG/VERBOSE/VERY_VERBOSE`

### Threading & Constructor Safety
- Avoid constructor-time asset loading
- UWidget construction can happen off-game-thread in UE5
- Defer asset loads to safe runtime points (e.g., NativeConstruct, NativeOnInitialized)

### Formatting
- **Indentation:** 4 spaces (UTF-8, max line 120 chars)
- **YAML files:** 2 spaces
- See `.editorconfig` for baseline

## Module Structure

**HorizonInteract (Runtime)**
- Location: `Plugins/HorizonInteract/Source/HorizonInteract/`
- Public headers: `Public/`
- Private implementation: `Private/`
- Logging/macros: `Private/HorizonInteractPrivate.h`

**Key Components:**
- `AHorizonInteractObject`: Base actor for interactive objects
- `AHorizonInteractCharacter`: Base character with interaction support
- `UHorizonInteractorComponent`: Component for interacting with objects
- `UHorizonInteractObjectComponent`: Component for interactive objects
- `UHorizonInteractObjectSelector`: Base class for selection logic

## Automation Tests

Tests are guarded by `WITH_DEV_AUTOMATION_TESTS`. When adding tests:
1. Follow existing pattern in `Plugins/HorizonInteract/Source/HorizonInteract/Private/Test/*.cpp`
2. Use `FAutomationTestBase` or `FAutomationSpecBase`
3. Register with Unreal automation macros
4. Name format: `Plugin.Category.PluginName.TestName`

## CI/CD

- Azure Pipelines: `.azure-pipelines/`
- Uses EpicGames templates (`verify-plugin-build.yml@templates`)
- UAT invoked via `RunUAT.*` in `Build/Base/Script/common.sh`

## Important Notes

- Prefer `Build/Script/` overrides first, then `Build/Base/Script/` shared scripts
- Shared scripts contain MSYS/Git-Bash conditionals (`OSTYPE == msys`)
- On Windows, run scripts from **Git Bash**
- No dedicated lint command; use IDE tooling for formatting
- No Cursor/Copilot rules found (`.cursorrules`, `.github/copilot-instructions.md`)

## Useful Paths

- Plugin descriptor: `Plugins/HorizonInteract/HorizonInteract.uplugin`
- Tests: `Plugins/HorizonInteract/Source/HorizonInteract/Private/`
- Build scripts: `Build/Script/` (overrides) and `Build/Base/Script/` (shared)
- CI config: `.azure-pipelines/`
