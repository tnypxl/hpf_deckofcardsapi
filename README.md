# API Tests for DeckOfCardsAPI.com

### Setup

```
$ git clone https://github.com/tnypxl/hpf_deckofcardsapi.git
$ cd hpf_deckofcardsapi
$ dotnet build
$ dotnet test
```

### Notes

* Its not really necessary to run `nunit test`. Its better to just run `dotnet test` instead. This is especially true when using the dotnet nunit template. 
* Sending a POST without a body is incorrect use the HTTP verb. It is much preferred to use GET in this case.