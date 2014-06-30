//
//  AnneProductCluster.m
//  MultiProductViewer
//
//  Created by JN on 2014-3-19.
//  Copyright (c) 2014 thoughtbot, inc. All rights reserved.
//

#import "AnneProductCluster.h"
#import "AnneProduct.h"

@implementation AnneProductCluster
//a modifier apres les tests et une fois avoir eu tous les format
+ (instancetype)productClusterWithTitle:(NSString *)title products:(NSArray *)products {
    AnneProductCluster *cluster = [[self alloc] init];
    cluster.title = title;
    cluster.products = products;
    return cluster;
}

+ (NSArray *)productClustersFromSpecs:(NSArray *)specs {
    NSMutableArray *clusters = [NSMutableArray arrayWithCapacity:[specs count]];
    for (NSDictionary *spec in specs) {
        NSString *title = spec[@"type"];
        NSArray *productSpecs = spec[@"anecdotes"];
        AnneProductCluster *cluster = [self productClusterWithTitle:title
                                                          products:[AnneProduct productsWithArray:productSpecs]];
        [clusters addObject:cluster];
    }
    return clusters;
}
@end

