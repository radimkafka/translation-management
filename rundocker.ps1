docker build -f .\TranslationManagement.Api\Dockerfile --force-rm -t translationmnagementapi .
docker run -it -p 5000:80 -e ASPNETCORE_URLS=http://+:80 translationmnagementapi 