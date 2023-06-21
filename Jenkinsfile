pipeline {
     agent any
     stages {
        stage("Run Docker image") {
            steps {
                sh 'docker build -t alexandrec0sta/pd2223'
            }
        }

        stage("Push Image to Docker Hub") {
            steps {
                // Log in to Docker Hub
                withDockerRegistry(credentialsId: 'dockerhub_id', url: 'https://registry.hub.docker.com') {
                    // Push the Docker image to Docker Hub
                    sh 'docker  push alexandrec0sta/pd2223:${commit_id}'
                }
            }
        }

        // stage("Execute Ansible") {

        // }
    }
}
