# Angular:
    npm install -g @angular/cli@latest
    ng new <ProjectName>
    cd <ProjectName>
    ng serve

## Packages
### Install
    npm install bootstrap --save
    npm install jquery --save
    npm install popper.js --save
    npm install @microsoft/signalr --save
### Configure
    "scripts": [
	               "node_modules/jquery/dist/jquery.min.js",
				   "node_modules/bootstrap/dist/js/bootstrap.min.js"              
               ]
	"styles": [
	              "src/styles.css",
	              "node_modules/bootstrap/dist/css/bootstrap.min.css"
              ]
## Other
    ng generate component <ComponentName>
    ng generate class <ClassName>