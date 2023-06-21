pipeline {
     agent any
     tools {
        'org.jenkinsci.plugins.docker.commons.tools.DockerTool' '18.09'
     }
     stages {
        stage("Run Docker Compose File") {
            steps {
                sh 'docker-compose build'
                sh 'docker-compose up -d'
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