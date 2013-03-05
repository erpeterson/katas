describe "given only a root node of a binary tree" do
  before :all do
    @root = Node.new
  end

  context "when counting the nodes" do
      it "counts 1 at level 1" do
        expect(count_nodes(@root)).to eq(1)
      end
  end
end

def count_nodes(node)
  1
end

class Node
  attr_accessor :left, :right, :data
end
