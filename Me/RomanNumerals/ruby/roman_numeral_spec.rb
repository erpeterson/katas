

describe "given a roman numeral" do
  context "when converting it to an arabic numeral" do
    {
      "" => 0,
      "I" => 1
    }.each_pair do |roman, arabic|
      it "converts #{roman} string to #{arabic}" do
        expect(convert(roman)).to eq(arabic)
      end
    end
  end
end

def convert(roman)
  0
end