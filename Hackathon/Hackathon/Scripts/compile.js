var editor;
$(function () {
    editor = ace.edit("code");
    editor.setTheme("ace/theme/textmate");
    editor.getSession().setMode("ace/mode/csharp");
    editor.setShowPrintMargin(false);
    editor.setOptions({
        maxLines: Infinity,
        fontSize: "12pt"
    });
    editor.$blockScrolling = Infinity;
});




$(document).ready(function () {
    $("button").click(function () {
        var output = $("#output");
        output.text('');


        var to_compile = {
            "LanguageChoice": "1",
            "Program": editor.getValue(),
            "Input": $("#Input").val(),
            "CompilerArgs": ""
        };

        output.text("Waiting");

        $.ajax({
            url: "http://rextester.com/rundotnet/api",
            type: "POST",
            data: to_compile
        }).done(function (data) {
            output.text(data.Result);
        }).fail(function (data) {
            output.text("fail " + JSON.stringify(data) + " " + JSON.stringify(err));
        });

    });
});