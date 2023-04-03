# LOSFusionTest
Instruction
1.	Clone the repository or open in editor.
2.	Create a database in your local database server and map it with the project.
3.	In order to map with database update  connectionstring  in web.config file.
4.	Add a table in database as shown in image.
![image](https://user-images.githubusercontent.com/62981797/229080321-f941f6cf-76bf-4163-9886-4fbd18d6dd46.png)

5.	Run the project.
6.	Open the postman:
7.	Enter the https://localhost:44301/api/Account/Register
 ![image](https://user-images.githubusercontent.com/62981797/229080901-90ca65e1-a3b2-4aa3-9bfe-10280735fc1b.png)

8.	Once register the user, you can login by using the email and password.
 ![image](https://user-images.githubusercontent.com/62981797/229081014-aa96dc57-cfe3-495f-ad58-e91863c85d99.png)

9.	On successfully login it will return the access token. 
10.	The following endpoints can access by using this access_token. Add Bearer and token in authorization in header.
A.  GET: {host}/api/cars/get : parameter can be passed in query as minYear:{date-format} & maxYear{date-fromat}
![image](https://user-images.githubusercontent.com/62981797/229081119-4428339b-3b81-47ad-9d03-8232a45500af.png)

 

B.  GET: {host}/api/cars/getcarbyId
 
![image](https://user-images.githubusercontent.com/62981797/229081208-3316b395-1a21-4433-aa97-ea52ca7729c4.png)


C.  POST: GET: {host}/api/cars/Addupdatecar
 ![image](https://user-images.githubusercontent.com/62981797/229081284-b1a89ea3-2e89-45b1-b5ef-5f9d1546a2cb.png)

That’s all..!

