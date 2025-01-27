public class FeatureCollection
{
  
    public List<Feature> Features { get; set; }
}

public class Feature
{

    public Properties Properties { get; set; }
}

public class Properties
{
   
    public string Place { get; set; }

    // The 'mag' property in the JSON maps to this double
    public double Mag { get; set; }
}

