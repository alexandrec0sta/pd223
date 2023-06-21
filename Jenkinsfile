pipeline {
     agent any
     stages {
        stage("Run Docker Compose File") {
            steps {
                sh 'sudo docker-compose build'
                sh 'sudo docker-compose up -d'
            }
        }

        stage("Push Image to Docker Hub") {
            steps {
                // Log in to Docker Hub
                withDockerRegistry(credentialsId: 'dockerhub_id', url: 'https://registry.hub.docker.com') {
                    // Push the Docker image to Docker Hub
                    sh 'docker-compose push alexandrec0sta/pd2223:1.0'
                }
            }
        }

        // stage("Execute Ansible") {

        // }
    }
}