function wyborcwiczenia1() {
    $(".trening").html(
        '<form asp-page-handler="view" method="post">        <h3> Test coopera</h3 >           <h3 id="as"> Dystans (km)</h3>            <input type="number" name="dystanscooper" style="margin-top:5px" />          <input type="submit" name="myButonn" value="" /></input >    </form >'
    )
}

function wyborcwiczenia2() {
    $(".trening").html(
        '<form asp-page-handler="BiegNaSto" method="post" asp-antiforgery="true"><h3> Bieg na 100m</h3>     <h3> Czas(s)</h3>     <input type="number" name="czasnasto" style="margin-top:5px" />    <input type="submit" class="myButtonn" value="wyślij" /></form>'
    )
}
function wyborcwiczenia3() {
    $(".trening").html(
        '<form asp-page-handler="Cooper" method="post" asp-antiforgery="true"><h3> Wyciskanie sztangi</h3>     <h3> Max kg</h3>     <input type="number" name="maxkg" style="margin-top:5px" />    <input type = "submit" class= "myButtonn" value = "wyślij" />'
    )
}
function wyborcwiczenia4() {
    $(".trening").html(
        '<h3> Wyciskanie sztangi</h3>   <h3> Max ilosc</h3>    <input type="number" name="maxile" style="margin-top:5px" />    <h3 style="margin-top:7px">Max waga</h3>    <input type="number" name="maxilekg" style="margin-top:5px" />    <input type = "submit" class= "myButtonn" value = "wyślij" />'
    )
}
function wyborcwiczenia5() {
    $(".trening").html(
        '<h3> Celność strzałów</h3>  <h3> Rezultat</h3>     <input type="number" name="procentstrzalow" style="margin-top:5px" />    <input type = "submit" class= "myButtonn" value = "wyślij" />'
    )
}
function wyborcwiczenia6() {
    $(".trening").html(
        '<h3> Celność podań</h3>     <h3>Rezultat</h3>     <input type="number" name="procentpodan" style="margin-top:5px" />    <input type = "submit" class="myButtonn" value="wyślij" />'
    )
}