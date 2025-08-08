# vueapp

This template should help get you started developing with Vue 3 in Vite.

## Recommended IDE Setup

[VSCode](https://code.visualstudio.com/) + [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) (and disable Vetur) + [TypeScript Vue Plugin (Volar)](https://marketplace.visualstudio.com/items?itemName=Vue.vscode-typescript-vue-plugin).

## Customize configuration

See [Vite Configuration Reference](https://vitejs.dev/config/).

## Project Setup

```sh
npm install
```

### Compile and Hot-Reload for Development

```sh
npm run dev
```

### Compile and Minify for Production

```sh
npm run build
```

### Lint with [ESLint](https://eslint.org/)

```sh
npm run lint
```


### What makes this work with one app for Vue and .Net ?

1. vueapp project (vueapp.esproj) - edit project file 

		<PropertyGroup>
		    <StartupCommand>npm run dev</StartupCommand>
		    <JavaScriptTestRoot>.\</JavaScriptTestRoot>
		    <JavaScriptTestFramework>Jest</JavaScriptTestFramework>

		    <!-- Allows the build (or compile) script located on 		package.json to run on Build -->
		    <ShouldRunBuildScript>false</ShouldRunBuildScript>

		    <!-- Command to create an optimized build of the project 		that's ready for publishing -->
		    <>npm run build</	ProductionBuildCommand>

		    <!-- Folder where production build objects will be 	placed -->
		    <>$(MSBuildProjectDirectory)\dist</	BuildOutputFolder>

		</PropertyGroup>

1. coreApi Project 
	Important lines:

	<Project Sdk="Microsoft.NET.Sdk.Web">

		<PropertyGroup>

			<TargetFramework>net9.0</TargetFramework>
			<SpaRoot>..\vueapp</SpaRoot>
			<SpaProxyLaunchCommand>npm run dev</SpaProxyLaunchCommand>
			<SpaProxyServerUrl>https://localhost:7200</SpaProxyServerUrl>
			
		</PropertyGroup>
	...

1. Solution - Click on 'Configure Startup Projects'
	1. Can use just one or multiple
	1. ???

1. 
