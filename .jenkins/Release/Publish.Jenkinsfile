// .jenkins/Release/Jenkinsfile — release publish entrypoint for HorizonInteractDemo.
@Library('jenkins-unreal-pipeline-library') _

unrealReleaseDeployPipeline(
    upstreamJob: 'HorizonPlugin/HorizonInteractDemo/Build/Development',
    ugsBuildJob: 'HorizonPlugin/HorizonInteractDemo/Build/UGSBuild'
)