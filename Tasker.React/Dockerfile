FROM node:10
EXPOSE 443


WORKDIR /src

COPY ./ClientApp .


ENTRYPOINT ["npm start", "/src/ClientApp"]