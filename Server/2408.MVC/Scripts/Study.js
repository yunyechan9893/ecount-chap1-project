document.addEventListener('DOMContentLoaded', function () {
    const selectButton = document.getElementById('hi');
    let data = { Name: 'ÀçÈñ', Age: 27 };

    selectButton.addEventListener('click', function () {
        fetch('/Study/Select', {
            method: 'POST',
            Headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(response => response.json())
            .then(data => {
                if (data.isSuccess) {
                    console.log(data)
                    alert('Success')
                } else {
                    alert('Fail')
                }
            })
            .catch(error => {
                console.error('error: ', error);
                alret('An error occurred');
            })
    })
})