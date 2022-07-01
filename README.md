# ApartmentsApplication-RWA-Project
Project for "Deveopment of web applications" class at Algebra Univerity

Project consists from 3 parts:
  <li>Data layer (Class library)</li>
  <li>Admin application ASP.NET Webforms</li>
  <li>Public application ASP.NET MVC</li>
  
  </br>
 SQL folder contains example database backup (.bak file) used by this application
  
  <h2>Public application</h2>
  </hr>
  
  <h3>Apartments page</h3>
  Features:
  <li>Anonymous access</li>
  <li>Apartments search with autocomplete</li>
  <li>Apartments are displayed with Ajax call to backend</li>
  <li>Filtering by avaliability and multiple sorting options</li>
  ![Screenshot (2)](https://user-images.githubusercontent.com/67825601/176955088-d8b4377e-8203-4071-9de4-5656a458282b.png)

  <h3>Apartment view</h3>
  Features:
  <li>Anonymous access</li>
  <li>Bootsrap carousel, images are swapping automatically, first picture is representative pictrue specified in admin application</li>
  <li>List of tags, basic information, title for every pictire (if exists)</li>
  <li>Reservation form that is automatically filled with logged user data</li>
  <li>Apartment star rating (cumulative rating from all reviews 4.5 rating = 5 stars)</li>
  <li>User reviews fetched by Ajax call</li>
  <li>Review form that can only be sent by logged user, (POST method by Ajax)</li>
![Screenshot (8)](https://user-images.githubusercontent.com/67825601/176955513-59415d7e-9997-4708-b14b-8225e8288ede.png)

  
  <h2>Admin application</h2>
  </hr>
 <h3>Login page</h3>
 
![login](https://user-images.githubusercontent.com/67825601/173871726-f4c2a086-341b-4abc-8abf-329002a1dbc8.png)

  <h3>Dashboard page</h3>
  
  ![dashboard](https://user-images.githubusercontent.com/67825601/173867409-a6c46742-dda3-4c36-996a-4ff179b68e95.png)
  
  <h3>Dashboard page / Create new apartment form</h3>
  
![createapartment](https://user-images.githubusercontent.com/67825601/173867965-6c05ac01-474e-4f18-9d25-65d31690f556.png)

  <h3>Dasboard page / Edit current apartment form</h3>
  
  ![editapartment](https://user-images.githubusercontent.com/67825601/173869822-259fbc62-df43-4b9b-9b19-8faac96cbe19.png)

<h3>Dashboard page / Delete apartment dialog (soft delete)</h3>

![apartmentdelete](https://user-images.githubusercontent.com/67825601/173870386-3597e73c-8e97-41ae-9a2b-2c9865f403e5.png)

  <h3>Tags page</h3>
  
  ![tags](https://user-images.githubusercontent.com/67825601/173870764-13d5e42a-3495-4f23-8eeb-704e4af57eb5.png)

  <h3>Tags page / Create new tag</h3>
  
  ![createtag](https://user-images.githubusercontent.com/67825601/173871210-b4212974-b181-4848-9ea9-cd7008527732.png)
  
  <h3>Tags page / Delete selected tag (tag without foreign records)</h3>
  
  ![deletetag](https://user-images.githubusercontent.com/67825601/173871523-b60dab6d-2241-4cd2-ac53-01c329f7ec09.png)

<h3>Users page</h3>

![users](https://user-images.githubusercontent.com/67825601/173872222-061923eb-0680-4fa2-b369-dbed0ac8ad21.png)

