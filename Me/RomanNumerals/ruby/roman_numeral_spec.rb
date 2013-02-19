describe "given a roman numeral" do
  context "when converting it to an arabic numeral" do
    {
      "" => 0,
      "I" => 1,
      "II" => 2,
      "III" => 3,
      "IV" => 4,
      "V" => 5
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
  match = Conversions.find { |x| x[0] == roman }
  return match[1] if match

  return 1 + convert(roman[1, roman.length - 1])
end
