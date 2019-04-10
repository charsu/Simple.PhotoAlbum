# Simple.PhotoAlbum
web api proof of concept for fetching data (static) for albums and photos

### endpoints 

[GET]api/photos - get all photos 
[GET]api/photos/[id] - get photo with id 
[GET]api/photos/foruser/[userid] - get photos that are linked for that userid (link through album) 

[GET]api/album - get all albums 
[GET]api/album/[id] - get album with id 
[GET]api/album/foruser/[userid] - get all albums that are linked for that userid 

### notes: 
- unit tests are included and have been developed using TDD.
