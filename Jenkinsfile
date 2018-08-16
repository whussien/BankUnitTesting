pipeline {
    agent {
		node {
			customWorkspace 'C:\\Jenkins\\workspaces\\asp.net-example-scmpipeline'
		}
	}
    stages {
        stage('Build') {
            steps {
                bat "C:\\Tools\\nuget\\nuget.exe restore"
				bat "C:\\Tools\\MSBuild\\14.0\\Bin\\amd64\\MSBuild.exe Bank\\Bank.csproj"
				bat "C:\\Tools\\MSBuild\\14.0\\Bin\\amd64\\MSBuild.exe BankTest\\BankTest.csproj"
            }
        }
        stage('Test') {
            steps {
				bat "C:\\Tools\\mstest\\MSTest.exe /resultsfile:BankTest.trx /noisolation /testcontainer:%WORKSPACE%\\BankTest\\bin\\Debug\\BankTest.dll"
            }
        }
        stage('Deploy') {
            steps {
                echo 'Hello world!' 
            }
        }
    }
}