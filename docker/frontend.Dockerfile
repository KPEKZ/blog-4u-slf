FROM node:24-alpine AS build

WORKDIR /app

COPY frontend/package*.json ./

RUN npm i --force && npm cache clean --force

COPY frontend/ .

EXPOSE 4200

CMD ["npm", "run", "start:prod"]
