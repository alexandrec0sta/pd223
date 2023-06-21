pipeline {
     agent any
     environment {
          registry = "alexandrec0sta/pd2223"
          registryCredential = 'dockerhub_id'
          dockerImage = ''
     }
     tools {
          docker 'docker'
     }
     stages {
          stage("Build Image") {
               steps {
                    script {
                         dockerImage = docker.build registry + ":$BUILD_NUMBER"
                    }
               }
          }
    }
}
