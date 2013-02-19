describe "given a roman numeral" do
  context "when converting it to an arabic numeral" do
    {
      "" => 0,
      "I" => 1,
      "II" => 2,
      "III" => 3,
      "IV" => 4,
      "V" => 5,
      "VI" => 6
    }.each_pair do |roman, arabic|
      it "converts #{roman} string to #{arabic}" do
        expect(convert(roman)).to eq(arabic)
      end
    end
  end
end

Conversions = [["V", 5], ["IV", 4], ["I", 1]]

def convert(roman)
  return 0 if roman.empty?
  match = Conversions.find { |x| roman.start_with? x[0] }
  return match[1] + convert(roman[match[0].length, roman.length - 1])
end
