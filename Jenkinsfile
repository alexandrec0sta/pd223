pipeline {
     agent any
     environment {
          registry = "alexandrec0sta/pd2223"
          registryCredential = 'dockerhub_id'
          dockerImage = ''
     }
     tools {
         nodejs 'nodejs'
         docker 'docker'
     }
     stages {
          stage('Cloning our Git') {
               steps {
                    git 'https://github.com/YourGithubAccount/YourGithubRepository.git'
               }
          }
          stage("Build Image") {
               script {
                    dockerImage = docker.build registry + ":$BUILD_NUMBER"
               }
          }
    }
}
