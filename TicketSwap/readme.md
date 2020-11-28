Angular:  
		npm install -g @angular/cli@latest
		ng new <ProjectName>
		cd <ProjectName>
		ng serve
Additional stuff:  
		npm install bootstrap --save
		npm install jquery --save
		npm install popper.js --save
		npm install @aspnet/signalr --save
		npm install @microsoft/signalr --save
Configure:  
		"scripts": [
              "node_modules/jquery/dist/jquery.min.js",
			  "node_modules/bootstrap/dist/js/bootstrap.min.js"              
            ]
		"styles": [
              "src/styles.css",
              "node_modules/bootstrap/dist/css/bootstrap.min.css"
            ]  
Components:  
		ng g c <ComponentName>  
Class:  
		ng g class <ClassName>  
