pipeline {
     agent any
       environment {
          DOCKERHUB_CREDENTIALS = credentials('dockerhub_id')
       }
     stages {
          stage("Build Image") {
               steps {
                    sh 'docker build -t alexandrec0sta/pd2223 .'
               }
          }
           stage('Login') {
                steps {
                  sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
                }
          }
          stage('Push') {
               steps {
             sh 'docker push lexandrec0sta/pd2223'
           }
         }
    }
}
