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

  context "when counting the nodes of a binary tree with two levels" do
    before :all do
      @root = Node.new
      @root.left = Node.new
      @root.right = Node.new

      @counts = count_nodes(@root)
    end

    it "counts 1 at level 1" do
      expect(@counts[0]).to eq(1)
    end

    it "counts 2 at level 2" do
      expect(@counts[1]).to eq(2)
    end
  end
end

def count_nodes(node)
  level_counts = []

  level_counts[0] = 1 unless node.nil?

  level_counts[1] = 0
  level_counts[1] += 1 unless node.left.nil?
  level_counts[1] += 1 unless node.right.nil?

  level_counts
end

class Node
  attr_accessor :left, :right, :data
end
