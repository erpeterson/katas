describe "given the root node of a tree" do

  context "when counting the nodes of a tree with one node" do
    before :all do
      @root = Node.new

      @counts = count_nodes(@root)
    end

    it "counts 1 at level 1" do
      expect(@counts[0]).to eq(1)
    end
  end

  context "when counting the nodes of a tree with two nodes" do
    before :all do
      @root = Node.new
      @root.left = Node.new

      @counts = count_nodes(@root)
    end

    it "counts 1 at level 1" do
      expect(@counts[0]).to eq(1)
    end

    it "counts 1 at level 2" do
      expect(@counts[1]).to eq(1)
    end
  end
end

def count_nodes(node)
  1
end

class Node
  attr_accessor :left, :right, :data
end
