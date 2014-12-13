/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="../../typing/sammy/sammyjs.d.ts" />

var app: Sammy.Application = Sammy();
var router: Hack.Router = new Hack.Router("http://hackapi.azurewebsites.net/api/");

app.get('#/:abc', (context: Sammy.EventContext) => {
    console.log(context.params.abc);
    context.partial("abc", (context: Sammy.RenderContext) => {
    });
});
app.run('#/');