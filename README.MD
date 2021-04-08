# Hahn.ApplicatonProcess.Application

A fullstack application built with .net 5.0 on the server side and Aurelia Framework on the client. The web api was built using trending software patterns and designs such as Unit of work, DDD, Repository pattern and SOLID. The wb api also use EntityFramework.Inmemory, Fluent Api, Fluent Validation, Automapper.




## Installation

### Prerequisities
Docker needs to be installed.


Clone current project with git

```bash
git clone {url}
```

Project has been dockerised and image can be created with the command

```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
Once this is completed the application can be reached on 

http://localhost:8000/home

Swagger url: http://localhost:8000/swagger


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Contact

* [GitHub](https://github.com/gbubemismith)
* [Dev.to](https://dev.to/smiththe_4th)
* [LinkedIn](https://www.linkedin.com/in/gbubemi-smith-a7a99034/)

## License
[MIT](https://choosealicense.com/licenses/mit/)