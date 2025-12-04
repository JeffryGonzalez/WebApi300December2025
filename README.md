# Web API 300

## Setup

Make sure Docker Desktop is running.

Open a terminal in the `~/class/WebApi300` directory and run the following:

```sh
echo "Removing all of your docker images"
docker rm -f $(docker ps -aq)
echo "Removing all your docker volumes"
docker volume rm $(docker volume ls -q)
```

To get my current code:

```sh
npx gitpick JeffryGonzalez/WebApi300December2025/tree/main/src/day4 ./src/day4
```

## Other Stuff

For the Yarp Demo / Versioning;

```sh
npx gitpick JeffryGonzalez/WebApi300December2025/tree/main/src/ChangeAuthority ./src/ChangeAuthority
```

For the The Software Center Thing with the Angular App

```sh
npx gitpick JeffryGonzalez/WebApi300December2025/tree/main/src/SoftwareCenter ./src/SoftwareCenter
```

If you want my notes and drawings and stuff:

```sh
npx gitpick JeffryGonzalez/WebApi300December2025/tree/main/notes ./Jeff-Notes
```

If you want to pull my latest later and overwrite what you have:

```sh
npx gitpick JeffryGonzalez/WebApi300December2025/tree/main/src/day3 ./src/day3 -o
```
