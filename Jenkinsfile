pipeline {
    agent any

    stages {

        stage('Run Docker image') {
            steps {
                sh 'docker-compose build'
                sh 'docker-compose up -d'
            }
        }

        stage('Push Image to Docker Hub') {
            steps {
                // Log in to Docker Hub
                withDockerRegistry(credentialsId: 'dockerhubaccount', url: 'https://registry.hub.docker.com') {
                    // Push the Docker image to Docker Hub
                    sh 'docker  push alexandrec0sta/pd2223:latest'
                }
            }
        }

        // stage("Execute Ansible") {
        // }
    }
}
