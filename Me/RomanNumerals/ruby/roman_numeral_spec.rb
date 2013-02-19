describe "given a roman numeral" do
  context "when converting it to an arabic numeral" do
    {
      "" => 0,
      "I" => 1,
      "II" => 2,
      "III" => 3,
      "IV" => 4,
      "V" => 5,
      "VI" => 6,
      "VII" => 7,
      "VIII" => 8,
      "IX" => 9,
      "X" => 10,
      "XI" => 11,
      "XIV" => 14,
      "XV" => 15,
      "XL" => 40,
      "L" => 50,
      "XC" => 90,
      "C" => 100,
      "CD" => 400,
      "D" => 500,
      "CM" => 900,
      "M" => 1000,
      "MCMXCIV" => 1994
    }.each_pair do |roman, arabic|
      it "converts #{roman} string to #{arabic}" do
        expect(convert(roman)).to eq(arabic)
      end
    end
  end
end

Conversions = [["M", 1000], ["CM", 900], ["D", 500],
               ["CD", 400], ["C", 100], ["XC", 90],
               ["L", 50], ["XL", 40], ["X", 10],
               ["IX", 9], ["V", 5], ["IV", 4], ["I", 1]]

def convert(roman)
  return 0 if roman.empty?
  match = Conversions.find { |x| roman.start_with? x[0] }
  return match[1] + convert(roman[match[0].length, roman.length - 1])
end
