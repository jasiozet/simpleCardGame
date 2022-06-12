module Logic

type Card = {
  img: string;
  title: string;
  ability: string;
  alternative: string;
  id: int;
}

let exampleCards: Card List =
  [
    {
      img="https://cdn.britannica.com/55/174255-050-526314B6/brown-Guernsey-cow.jpg";
      title="Cow";
      ability="Eat grass";
      alternative="Give milk";
      id=1;
    };
    {
      img="https://previews.123rf.com/images/monticello/monticello1306/monticello130600032/20330858-brown-chicken-in-grass.jpg";
      title="Chicken";
      ability="Eat grain";
      alternative="Give eggs";
      id=2;
    };
    {
      img="https://media.istockphoto.com/photos/newborn-piglet-on-spring-green-grass-on-a-farm-picture-id956025942?k=20&m=956025942&s=612x612&w=0&h=YENs9eney3fZT6qp3Trg-wnzqwWJLd1QGdbL7WcTpJU=";
      title="Sheep";
      ability="Eat grass";
      alternative="Give wool";
      id=3;
    }
  ]