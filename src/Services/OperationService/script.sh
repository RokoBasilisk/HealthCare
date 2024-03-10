// run redis
docker run -p 6379:6379 -d -v redis-data:/data --env REDIS_PASSWORD=pMA63033n6tF redis

// run operation service
docker run -p 8181:8181 -d operationservice:dev