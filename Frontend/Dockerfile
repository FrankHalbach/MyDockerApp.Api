# Use an official Node.js runtime as a parent image
FROM node:latest

# Set the working directory
WORKDIR /usr/src/app

# Copy package.json and package-lock.json (if available)
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of your application
COPY . .

# Expose the port that Nuxt.js will run on
EXPOSE 3000

# Build and start the application
# RUN npm run build
CMD ["npm", "run", "dev"]




