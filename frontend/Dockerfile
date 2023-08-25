#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM node:18-alpine AS base
WORKDIR /app

COPY package.json .
COPY package-lock.json .

RUN npm ci

COPY . .

RUN npm run build

FROM nginx:1.25.2-perl
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*

COPY --from=base /app/dist .
ENTRYPOINT ["nginx","-g","daemon off;"]