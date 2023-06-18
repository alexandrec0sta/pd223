pipeline {
     agent any
     tools {
         nodejs 'nodejs'
     }
     stages {
        stage("Build FrontEnd") {
            steps {
                sh "cd fe-nasa"
                sh "npm install"
                sh "npm run build"
            }
        }
    }
}