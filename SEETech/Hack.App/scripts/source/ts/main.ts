/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="../../typing/sammy/sammyjs.d.ts" />

var app: Sammy.Application = Sammy();
app.get('#:foobar', (context) => {
    console.log(this.params.foobar);
});
app.run('#');