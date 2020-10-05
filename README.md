# Insurance Premium Calculate
The design is to implement two projects . 
1. Premium-Demo:- Web APi project which gives the occupations lookup and also calculate premium based on age, cover and occupation. Swagger documentation is provided for api testing without front end. 
2. SPA:- Single page Angular app with a reactive form for required fields. Material form controls are used for quick development . 

 To start project :-
1.  Clone / download the github repository.
2.  Open the solution in visual studio and set both premium-demo and SPA as startup projects
3. Goto  SPA folder from commandline and do an npm install
4. Rebuild the solution and start. Two .net core servers should run (one for api and other for SPA ).
5. Go to localhost:5001 . Enter the form fields , when all mandatory fields are entered the premium is displayed below

# Note
The project requires .Net core 3.1 and lates version of angular cli installed
