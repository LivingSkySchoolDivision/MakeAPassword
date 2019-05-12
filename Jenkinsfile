pipeline {
    agent any
    environment {
        REPO = "makeapassword'
        PRIVATE_REPO = "${PRIVATE_DOCKER_REGISTRY}/${REPO}"
        TAG = "j-${env.BUILD_NUMBER}"
    }
    stages {
        stage('Git clone') {
            steps {
                git branch: 'master',
                    credentialsId: 'JENKINS-AZUREDEVOPS',
                    url: 'git@ssh.dev.azure.com:v3/LivingSkySchoolDivision/MakeAPassword/MakeAPassword'
            }
        }
        stage('Docker build') {
            steps {
                dir("LSSDPasswordGenCore") {
                    sh "docker build --no-cache -t ${PRIVATE_REPO}:latest -t ${PRIVATE_REPO}:${TAG} ."
                }
            }
        }
        stage('Docker push') {
            steps {
                sh "docker push ${PRIVATE_REPO}:${TAG}"
                sh "docker push ${PRIVATE_REPO}:latest"           
            }
        }
    }
    post {
        failure {
            mail to:'jenkinsalerts@lskysd.ca',
                subject: "Failed Pipeline: ${currentBuild.fullDisplayName}",
                body: "Something is wrong with ${env.BUILD_URL}"
        }
        success {
            mail to:'jenkinsalerts@lskysd.ca',
                subject: "Build pipeline completed successfully: ${currentBuild.fullDisplayName}",
                body: "${env.BUILD_URL}"
        }
        always {
            deleteDir()
        }
    }
}