# File Integrity Monitoring System

The **File Integrity Monitoring System** is a robust and secure application built using WPF (Windows Presentation Foundation) and C# to ensure the integrity of critical files by leveraging the SHA-256 hashing algorithm. This system is designed to detect unauthorized changes to essential files, maintain detailed logs of file modifications, and empower administrators to review and analyze the history of changes.


https://github.com/ShouryaSrivastava01/FIM-File_Integrity_Manager/assets/72685413/f08abb31-0a3b-423e-ad20-b2f3fe7fdb9f



## Features

1. **SHA-256 Hashing**: The system utilizes the SHA-256 hashing algorithm to generate unique cryptographic hash values for each critical file. This ensures that any unauthorized changes to these files are immediately detectable.

2. **Unauthorized Change Detection**: Whenever a file undergoes modification, the system automatically compares the newly generated hash with the previously stored hash. If a mismatch is detected, it signifies an unauthorized change, and an alert is triggered.

3. **Log Storage**: The system maintains comprehensive logs of file modifications, including details such as the timestamp of the change, the user responsible, and the specific file affected. This historical data is invaluable for tracking changes and identifying potential security breaches.

4. **Administrator Access**: Authorized administrators can access and review the log files through a user-friendly interface. This feature allows administrators to analyze the history of file changes, identify patterns, and take appropriate action when necessary.

## System Requirements

- Windows Operating System
- .NET Framework
- WPF and C# runtime libraries

## Getting Started

1. **Clone the Repository**: Start by cloning this repository to your local machine.

    ```shell
    https://github.com/ShouryaSrivastava01/FIM-File_Integrity_Manager.git
    ```

2. **Build the Application**: Open the project in your preferred IDE or text editor, and build the application.

3. **Run the Application**: Execute the application, and you'll be presented with the user interface.

4. **Configure File Monitoring**: Define the critical files and directories you want to monitor within the application.

5. **Review Logs**: Administrators can access the log section to review and analyze file changes.

## Usage

- Upon detecting an unauthorized change, the system will immediately notify administrators, ensuring swift action can be taken.

- Regularly review the logs to maintain a thorough understanding of file modifications and system integrity.


## Acknowledgments

We would like to express our gratitude to the open-source community and the developers who have contributed to the libraries and tools used in this project.

