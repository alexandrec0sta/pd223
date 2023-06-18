pipeline {
     agent any
     tools {
         nodejs 'nodejs'
     }
     stages {
        stage("Build FrontEnd") {
            steps {
                dir("${env.WORKSPACE}/fe-nasa") {
                  sh "npm install"
                  sh "npm run build"
                }
            }
        }
    }
}