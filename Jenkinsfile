pipeline {
     agent any
     stages {
        stage("Run Docker Compose File") {
            sh 'sudo docker-compose build'
            sh 'sudo docker-compose up -d'
        }

        stage("Push Image to Docker Hub") {
            // Log in to Docker Hub
            withDockerRegistry(credentialsId: 'dockerhub_id', url: 'https://registry.hub.docker.com') {
                // Push the Docker image to Docker Hub
                sh 'docker-compose push'
            }
        }

        stage("Execute Ansible") {

        }
    }
}