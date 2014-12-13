/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="../../typing/sammy/sammyjs.d.ts" />
var _this = this;
var app = Sammy();
app.get('#:foobar', function (context) {
    console.log(_this.params.foobar);
});
app.run('#');
//# sourceMappingURL=main.js.map
