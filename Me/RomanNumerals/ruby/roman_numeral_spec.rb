

describe "given a roman numeral" do
  context "when converting it to an arabic numeral" do
    it "converts an empty string to 0" do
      expect(convert("")).to eq(0)
    end
  end
end

def convert(roman)
end
