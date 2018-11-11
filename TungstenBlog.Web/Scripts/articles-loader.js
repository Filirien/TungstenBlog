    $(function () {
        loadArticles();
    });
    $("#button").click(function () {
        $("#article-container .row").empty(); 
    loadArticles();
});

    function loadArticles() {
        $.ajax({
            url: '/api/articleapi',
            dataType: 'json',
            success: function (json) {
                for (var item of json) {
                    let categories = item.Categories.map(x => `<p class="card-text">${x}</p>`).join("");
                    $('#article-container .row').append(
                        `<div class="card col-sm-4">
                                    <img class="img-responsive card-img-top" src="${item.Enclosure.Url}" alt="No Image" />
                                    <div class="card-body">
                                        <h3 class="card-title">${item.Title}</h3>
                                            <p class="card-text">${item.Description}</p>
                                        <p class="card-text">${item.PubDate}</p>
                                       <p class="card-text">
                                            ${categories}
                                        </p>
                                        <a href="${item.Guid}" class="btn btn-primary">Read More...</a>
                                        <br />
                                    </div>
                                </div>`
                    );
                }
            }
        });
    }