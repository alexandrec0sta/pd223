pipeline {
     agent any
     environment {
          registry = "alexandrec0sta/pd2223"
          registryCredential = 'dockerhub_id'
          dockerImage = ''
     }
     stages {
          stage('Cloning our Git') {
               steps {
                    git 'https://github.com/YourGithubAccount/YourGithubRepository.git'
               }
          }
          stage("Build Image") {
               steps {
                    script {
                         dockerImage = docker.build registry + ":$BUILD_NUMBER"
                    }
               }
          }
    }
}
