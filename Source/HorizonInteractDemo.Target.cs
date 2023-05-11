// Fill out your copyright notice in the Description page of Project Settings.

using UnrealBuildTool;
using System.Collections.Generic;

public class HorizonInteractDemoTarget : TargetRules
{
	public HorizonInteractDemoTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;

		ExtraModuleNames.AddRange( new string[] { "HorizonInteractDemo" } );
        //{
        //    bUsePCHFiles = false;
        //    bUseSharedPCHs = false;
        //    bUseUnityBuild = false;
        //}
    }
}
