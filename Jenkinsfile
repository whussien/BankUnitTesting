pipeline {
    agent any 
    stages {
        stage('Build') {
            steps {
                bat 'C:\Tools\nuget\nuget.exe restore'
				bat 'C:\Tools\MSBuild\14.0\Bin\amd64\MSBuild.exe Bank\Bank.csproj'
				bat 'C:\Tools\MSBuild\14.0\Bin\amd64\MSBuild.exe BankTest\BankTest.csproj'
            }
        }
        stage('Test') {
            steps {
                echo 'Hello world!' 
            }
        }
        stage('Deploy') {
            steps {
                echo 'Hello world!' 
            }
        }
    }
}